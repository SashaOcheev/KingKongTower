using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    [SerializeField]
    private GameObject _block;

	void Start ()
    {
        //Invoke("Inst", 2f);
        StartCoroutine(InstObj());
    }
	
	void Update () {
    }

    void CreateNextBlock()
    {
        var position = new Vector3(_block.transform.position.x, _block.transform.position.y + HeightShift, _block.transform.position.z);
        _block = Instantiate(_block, position, Quaternion.identity);
        _block.name = DateTime.UtcNow.ToString();
    }

    private float HeightShift
    {
        get
        {
            var height = _block.GetComponent<BoxCollider>().size.y;
            var scale = _block.GetComponent<Transform>().localScale.y;
            float shift = height * scale;

            return shift;
        }
    }

    IEnumerator InstObj()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            CreateNextBlock();
        }
    }

    void Inst()
    {
        CreateNextBlock();
    }
}
