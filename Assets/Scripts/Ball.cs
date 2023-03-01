using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    private Vector3 direction;

    public float speed;

    [SerializeField]
    private int playerOneScorePoints;
    
    [SerializeField]
    private int playerTwoScorePoints;
    
    private Vector3 spawnPoint;

    public Text playerOneScoreText;
    public Text playerTwoScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerOneScorePoints = 0;
        playerTwoScorePoints = 0;
        this.direction = new Vector3(1f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * speed;
        playerOneScoreText.text = playerOneScorePoints.ToString();
        playerTwoScoreText.text = playerTwoScorePoints.ToString();
    }

    void OnCollisionEnter (Collision c)
    {
        Vector3 normal = c.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);

        if(c.gameObject.name == "WallL")
        {
            playerTwoScorePoints++;
            transform.position = spawnPoint;
        }

        if (c.gameObject.name == "WallR")
        {
            playerOneScorePoints++;
            transform.position = spawnPoint;
        }
    }
}
