using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.5f;
    private float xBound = 25.0f;
    private float zBound = 25.0f;
    public GameObject fireBall;
    public GameObject iceBall;
    public GameObject lightningBall;
    public GameObject arcaneBall;
    private int lives = 3;
    Vector3 launchPos;


    // Start is called before the first frame update
    private int spellType = 1;
    void Start()
    {
        launchPos = new Vector3(0, 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput);
        transform.Translate(Vector3.right * speed * horizontalInput);
        if (transform.position.x <= -xBound) {//player cannot move farther left than left bound
            transform.position = new UnityEngine.Vector3(-xBound, transform.position.y, transform.position.z);
        } else if (transform.position.x >= xBound) {//player cannot move farther right than right bound
            transform.position = new UnityEngine.Vector3(xBound, transform.position.y, transform.position.z);
        }
        
        if (transform.position.z <= -zBound) {//player cannot move farther down than bottom bound
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, -zBound);
        } else if (transform.position.z >= zBound) {//player cannot move farther up than top bound
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (Input.GetKeyDown("1"))
        {
            //set to fire
            spellType = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            //set to ice
            spellType = 2;
        }
        if (Input.GetKeyDown("3"))
        {
            //set to lightning
            spellType = 3;
        }
        if (Input.GetKeyDown("4"))
        {
            //set to arcane
            spellType = 4;
        }

        //space will launch spell, but only ball of specified type from above.
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))//can use spacebar or left-click
        {
            switch (spellType)
            {
                case 1:
                    //launch fireball
                    Instantiate(fireBall, transform.position + launchPos, fireBall.transform.rotation);
                    
                    break;
                case 2:
                    //launch iceball
                    Instantiate(iceBall, transform.position + launchPos, iceBall.transform.rotation);
                    
                    break;
                case 3:
                    //launch lightning ball
                    Instantiate(lightningBall, transform.position + launchPos, lightningBall.transform.rotation);
                    
                    break;
                case 4:
                    //launch arcane ball
                    Instantiate(arcaneBall, transform.position + launchPos, arcaneBall.transform.rotation);
                    
                    break;
            }
            
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FireWizard" || other.gameObject.name == "IceWizard" || other.gameObject.name == "LightningWizard" || other.gameObject.name == "ArcaneWizard")
        {
            Destroy(other.gameObject);
            Debug.Log("Player has collided with enemy and has lost one life");
            //FIXME: remove 1 player life
            lives--;
            if (lives == 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
