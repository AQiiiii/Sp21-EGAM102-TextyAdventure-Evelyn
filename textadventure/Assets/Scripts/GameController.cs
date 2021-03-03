using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public List<string> SceneInventory, PlayerInventory;
   
    public Text OutputText;

    
    public Scrollbar VerticalScrollbar;

    public InputField InputText;

    
    private char[] spaceCharacter = new[] { ' ' };

  
    void Start()
    {
       
        OutputText.text = "The game is afoot!";
       
        Invoke("MoveScrollbarToBottom", .1f);
        PlayerInventory = new List<string>();
    }

    void MoveScrollbarToBottom()
    {
        VerticalScrollbar.value = 0;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            InputText.text = InputText.text.ToLower();

            
            string[] inputWords = InputText.text.Split(spaceCharacter);

           
            if (inputWords[0] == "hello" && inputWords[1] == "world")
            {
                
                OutputText.text += "The world is silent\n";
               
                Invoke("MoveScrollbarToBottom", .1f);
            }
            if (inputWords[0] == "talk" && inputWords[1] == "w")
            {
                
                OutputText.text += "Hello! W speaking, how may I help you?";
                PlayerInventory.Add("door");
                PlayerInventory.Add("snake");
               
                Invoke("MoveScrollbarToBottom", .1f);
                
                if(inputWords[3] == "door" && PlayerInventory.Contains("door"))
                {
                    OutputText.text += "Go straight for 30 meters, then turn right and walk 10 meters. There is a gate.";
               
                    Invoke("MoveScrollbarToBottom", .1f);
                }
                if(inputWords[3] == "snake" && PlayerInventory.Contains("snake"))
                {
                    OutputText.text += "There's a snake behind you!";
               
                    Invoke("MoveScrollbarToBottom", .1f);
                }
  
            }
            

            else if (inputWords[0] == "get")
            {
                if(inputWords[1] == "hat" && SceneInventory.Contains("hat")) 
                {
                    SceneInventory.Remove("hat");
                    GameObject.Find("BaseballCap").GetComponent<SpriteRenderer>().enabled = false;
                    PlayerInventory.Add("hat");
                    
                    OutputText.text += "you pick up the hat!";
               
                    Invoke("MoveScrollbarToBottom", .1f);

                }
                if(inputWords[1] == "mask" && SceneInventory.Contains("mask")) 
                {
                    SceneInventory.Remove("mask");
                    GameObject.Find("mask").GetComponent<SpriteRenderer>().enabled = false;
                    PlayerInventory.Add("mask");
                    
                    OutputText.text += "you pick up the mask!";
               
                    Invoke("MoveScrollbarToBottom", .1f);

                }

                else 
                {
                    OutputText.text += "There is no " + inputWords[1]+".\n";
               
                    Invoke("MoveScrollbarToBottom", .1f);    
                }
            }
            else if(inputWords[0] == "wear")
            {
                if(inputWords[1] == "hat" && PlayerInventory.Contains("hat"))
                {
                    GameObject.Find("HatOnHHead").GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    OutputText.text += "you don't have a " + inputWords[1]+".\n";
               
                    Invoke("MoveScrollbarToBottom", .1f); 
                }
                if(inputWords[1] == "mask" && PlayerInventory.Contains("mask"))
                {
                    GameObject.Find("maskonface").GetComponent<SpriteRenderer>().enabled = true;
                }
                
            }
            else if(inputWords[0] == "i")
            {
                string inventoryString = "You have:";
                for (int i = 0; i < PlayerInventory.Count; i++)
                {
                    inventoryString += PlayerInventory[i] + ",";
                }
                OutputText.text += inventoryString + "\n";
               
                Invoke("MoveScrollbarToBottom", .1f); 
            }
            else if(inputWords[0] == "look")
            {
                string SceneInventoryString = "things in this scene:";
                for (int i = 0; i < SceneInventory.Count; i++)
                {
                    SceneInventoryString += SceneInventory[i] + ",";
                }
                OutputText.text += SceneInventoryString + "\n";
               
                Invoke("MoveScrollbarToBottom", .1f); 
            }

            else
            {
                
                OutputText.text += "You can't do that, at least not now.\n";
              
                Invoke("MoveScrollbarToBottom", .1f);
            }

          
            InputText.text = "";
         
            InputText.ActivateInputField();
        }
    }

}
