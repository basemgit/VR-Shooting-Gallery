using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;
    public GameObject hitEffect;

    private void OnCollisionEnter(Collision collision)
    {
        // Handle collision logic here (e.g., damage the target)
        Debug.Log($"Bullet hit {collision.gameObject.name}");

        Vector3 effectPos = new Vector3(collision.transform.position.x, collision.transform.position.y + 2, collision.transform.position.z);

        if (collision.gameObject.CompareTag("Bottle"))
        {
            collision.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            Instantiate(hitEffect, effectPos, Quaternion.identity);

            collision.transform.gameObject.GetComponent<Bottle>().Explode();
            GameManager.Instance.IncreaseScore(1);
            GameManager.Instance.PlayGlassSound();

        }

        if (collision.gameObject.CompareTag("Bonus"))
        {
            Instantiate(hitEffect, effectPos, Quaternion.identity);
            collision.transform.gameObject.GetComponent<Bottle>().Explode();
            GameManager.Instance.IncreaseScore(5);
            GameManager.Instance.PlayGlassSound();
            GameManager.Instance.PlayBonusSound();
            GameManager.Instance.ShowBonusText(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Missed"))
        {
            Debug.Log("Missed");
        }


        Destroy(gameObject);
    }
}
