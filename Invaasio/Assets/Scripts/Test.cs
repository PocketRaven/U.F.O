using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Invader[] prefabs;

    public int rows = 5;

    public int columns = 11;

    //public float speed = 5.0f;

    //private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            //float width = 2.0f * (this.columns - 1);
            //float height = 2.0f * (this.rows - 1);
            //Vector2 centering = new Vector2(-width / 2, -height / 2);
            //Vector3 rowPositioning = new Vector3(centering.x, centering.y +(row * 2.0f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {

                Invader invader = Instantiate(this.prefabs[row], this.transform);
                //Vector3 position = rowPositioning;
                //position.x += col * 2.0f;
                //alukset.transform.localPosition = position;

            }
        }
    }

    //void Update()
    //{
    //  this.transform.position += _direction * this.speed * Time.deltaTime;
    //}
}