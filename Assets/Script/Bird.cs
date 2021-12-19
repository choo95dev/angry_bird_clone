using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPos;
    private bool _birdWasLaunched = false;
    private float _timeSittingAround;

    [SerializeField] private float _pushForce = 100f;

    private void Awake()
    {
        //save starting pos
        _initialPos = transform.position;
    }

    private void Update()
    {
        if(_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || _timeSittingAround > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPos = _initialPos - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPos * _pushForce);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        transform.position = newPos;
    }
}
