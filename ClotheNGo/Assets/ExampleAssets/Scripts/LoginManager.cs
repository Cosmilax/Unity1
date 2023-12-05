using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField usernameInputField;
    [SerializeField]
    private TMP_InputField passwordInputField;
    [SerializeField]
    private TextMeshProUGUI errorText;
    public GameObject LoginMenu;
    public GameObject submenu;
    /// <summary>
    /// Called when the submit is pressed. Will grab username and password and check they are correct
    /// </summary>
    public void OnSubmitLogin()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;
        ///Begin Checking
        Debug.Log("UserName: " + username);
        Debug.Log("Password: " + password);
        string loginCheckMessage = CheckLoginInfo(username, password);
        if(string.IsNullOrEmpty(loginCheckMessage))
        {
            Debug.Log("LOGIN");
            LoginMenu.SetActive(false);
            submenu.SetActive(true);
        }
        else
        {
            Debug.LogError("Error: " + loginCheckMessage);
            errorText.text = "Error: " + loginCheckMessage;
        }
    }
    private string CheckLoginInfo(string username, string password)
    {
        string returnString = "";

        // Check if either username or password is incorrect
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            returnString = "Please enter both username and password.";
        }
        else if (username == "admin" && password == "1")
        {
            returnString = "";
        }

        return returnString;
    }
   public void RemoveErrorText()
    {
        errorText.text = "";
    }
    public void RemoveUserPass()
    {
        usernameInputField.text = "";
        passwordInputField.text = "";
    }
}
