using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class VRMAvatarMover : MonoBehaviour
{
    public GameObject target;  // 目的地
    public float speed = 0.5f;  // 移動速度
    private Vector3 startPosition;  // スタート位置
    private Quaternion startRotation;  // スタート時の回転
    private Animator animator;
    private bool isReturning = false;  // 元の位置に戻るかどうか
    private bool isActivated = false;  // 動作が有効かどうか

    private UdpClient udpClient;
    private bool isRaisingHandAndReturning = false;  // 手を挙げて戻る処理中かどうかのフラグ

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        udpClient = new UdpClient();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated) return;  // 動作が無効なら何もしない

        Vector3 targetPosition = isReturning ? startPosition : new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        float stoppingDistance = isReturning ? 0.02f : 0.3f;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (distanceToTarget < stoppingDistance)
        {
            animator.SetBool("isWalking", false);

            if (!isReturning)
            {
                StartCoroutine(RaiseHandAndReturn());
            }
            else
            {
                isActivated = false;
                isReturning = false;
            }
        }
        else
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            Vector3 newPosition = new Vector3(
                transform.position.x + direction.x * speed * Time.deltaTime,
                transform.position.y,
                transform.position.z + direction.z * speed * Time.deltaTime
            );
            transform.position = newPosition;

            Vector3 lookAtTarget = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            transform.LookAt(lookAtTarget);

            animator.SetBool("isWalking", true);
            animator.SetBool("isRaisingHand", false);
        }
    }

    IEnumerator RaiseHandAndReturn()
    {
        if (isRaisingHandAndReturning)
        {
            yield break;
        }

        isRaisingHandAndReturning = true;

        animator.SetBool("isRaisingHand", true);
        yield return new WaitForSeconds(2);

        Send("Light");
        Debug.Log("send command");

        yield return new WaitForSeconds(3);

        animator.SetBool("isRaisingHand", false);
        isReturning = true;

        transform.rotation = startRotation;
        isRaisingHandAndReturning = false;
    }

    public void ActivateAndStart()
    {
        StopAllCoroutines();
        isActivated = true;
        isReturning = false;
        startPosition = transform.position;
        startRotation = transform.rotation;
        animator.SetBool("isWalking", false);
        animator.SetBool("isRaisingHand", false);
    }

    public void DelayAndStart()
    {
        StartCoroutine(DelayActivateAndStart());
    }

    private IEnumerator DelayActivateAndStart()
    {
        yield return new WaitForSeconds(2);
        ActivateAndStart();
    }

    private void Send(string message)
    {
        try
        {
            if (string.IsNullOrEmpty(GetESP32IP.esp32IpAddress))
            {
                Debug.LogError("ESP32 IP Address is not set.");
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, GetESP32IP.esp32IpAddress, 3334);
        }
        catch (SocketException e)
        {
            Debug.LogError($"SocketException: {e}");
        }
    }

    private void OnDestroy()
    {
        udpClient.Close();
    }
}
