using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRotation : MonoBehaviour
{

    [SerializeField] private float _speed = .3f;
    private Transform _transform;

 /*   private void Start()
    {
        StartRotation();
    }*/
    public void StartRotation()
    {
        _transform = this.GetComponent<Transform>();
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            _transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * _speed);
            yield return new WaitForFixedUpdate();
        }
    }
}
