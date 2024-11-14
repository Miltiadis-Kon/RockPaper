using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMananger : MonoBehaviour
{

    //Define life and death assets
    public GameObject life = new GameObject();
    public GameObject death = new GameObject();

    public Transform userLives;
    public Transform cpuLives;

    // Define texts
    public TMP_Text userOption;
    public TMP_Text userOptionDark;

    public TMP_Text comOption;
    public TMP_Text comOptionDark;


    // Test variables
    public int total_lives = 5;
    public int user_lives = 5;
    public int cpu_lives = 5;
    




    // Start is called before the first frame update
    void Start()
    {
        userOption.text = "";
        userOptionDark.text = "";

        comOption.text = "Awaiting...";
        comOptionDark.text = "Awaiting...";

        SetupLives();
    }

    // Update is called once per frame
    void Update()
    {
        string _option = previousOption;
        if (_option == "OK" || _option == "Pointer")
        {
            _option = "";
        }
        
        userOption.text = userOptionDark.text =  _option;
        // Test lives
        if (Input.GetKeyDown(KeyCode.Space))
        {
            user_lives--;
            UpdateLives(total_lives,user_lives , userLives);
        }

    }

    private void SetupLives()
    {
        UpdateLives(total_lives, user_lives, userLives);
        UpdateLives(total_lives, cpu_lives, cpuLives);
    }

    private string previousOption = "";
    public void UpdateUserOption(string option)
    {
        if (option != previousOption)
        {
            print(option);
            previousOption = option;
        }
    }



    private void UpdateLives(int total_lives,int lives,Transform parent)
    {
        if (lives< 0)
        {
           print("Game Over");
            // Game end
        }
        else
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < lives; i++)
            {
                GameObject newLife = Instantiate(life, parent);
            }

            for (int i = 0; i < total_lives - lives; i++)
            {
                GameObject newDeath = Instantiate(death, parent);
            }
        }
    }

}
