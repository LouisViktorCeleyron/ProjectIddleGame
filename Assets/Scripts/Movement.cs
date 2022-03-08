using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    private void Update()
    {
        float _x=0f, _z = 0f;
        if(Input.GetKey(KeyCode.Z))
        {
            _z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _x = 1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _x = -1;
        }

        transform.Translate(new Vector3(_x, 0, _z)*speed);
    }
}
