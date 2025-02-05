using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class studentDatabase : MonoBehaviour
{
    //profiles
    public InputField nameInput;
    public InputField ageInput;
    public InputField studentNumberInput;
    public InputField studentSection;
    public Text resultText;


    //search stuff
    public InputField searchInput;

    //save student data
    public void SaveStudentData()
    {
        string studentName = nameInput.text;
        int age;
        int studentNumber;
        string Section = studentSection.text;

        //checking if field are not empty and parse values
        if (!string.IsNullOrEmpty(studentName) &&
            int.TryParse(ageInput.text, out age) &&
            int.TryParse(studentNumberInput.text, out studentNumber) &&
            !string .IsNullOrEmpty(Section))
        {
            //save data in playerprefs
            PlayerPrefs.SetInt(studentName + "Age", age);
            PlayerPrefs.SetInt(studentName + "Student Number", studentNumber);
            PlayerPrefs.SetString(studentName + "Student Section", Section);
            PlayerPrefs.Save();
            Debug.Log("Student Data Saved: " + studentName);
        }
        else
        {
            Debug.Log("Invalid Input");
        }

    }

    //loading student data
    public void LoadStudentData()
    {
        string studentName = searchInput.text;
        if (PlayerPrefs.HasKey(studentName + "Age"))
        {
            int age = PlayerPrefs.GetInt(studentName + "Age");
            int studentnumber = PlayerPrefs.GetInt(studentName + "StudentNumber");
            string Section = PlayerPrefs.GetString(studentName + "Student Section");
            resultText.text = $"Name: {studentName}\nAge: {age}\nSN: {studentnumber}\nStudent Section: {Section}"; 
        }
        else{
            resultText.text = "Student Not Found";
        }
    }

}
