using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle2Script : MonoBehaviour
{
    public TMP_InputField aField;
    public TMP_InputField bField;
    public TMP_InputField cField;
    public TMP_InputField dField;
    //public TMP_InputField eField;
    public TMP_InputField fField;
    public TMP_InputField gField;
    public TMP_InputField hField;
    public TMP_InputField iField;
    public TMP_InputField jField;
    public TMP_InputField kField;
    //public TMP_InputField lField;
    public TMP_InputField mField;
    //public TMP_InputField nField;
    public TMP_InputField oField;
    //public TMP_InputField pField;
    //public TMP_InputField qField;
    public TMP_InputField rField;
    public TMP_InputField sField;
    //public TMP_InputField tField;
    public TMP_InputField uField;
    //public TMP_InputField vField;
    public TMP_InputField wField;
    public TMP_InputField xField;
    //public TMP_InputField yField;
    //public TMP_InputField zField;
    public int puzzleNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    bool checkInputs()
    {
        if (!aField.text.Equals("t") && !aField.text.Equals("T"))
        {
            return false;
        }
        if (!bField.text.Equals("i") && !bField.text.Equals("I"))
        {
            return false;
        }
        if (!cField.text.Equals("l") && !cField.text.Equals("L"))
        {
            return false;
        }
        if (!dField.text.Equals("h") && !dField.text.Equals("h"))
        {
            return false;
        }
        //if (!eField.text.Equals("d") && !eField.text.Equals("D"))
        //{
        //    return false;
        //}
        if (!fField.text.Equals("s") && !fField.text.Equals("S"))
        {
            return false;
        }
        if (!gField.text.Equals("u") && !gField.text.Equals("U"))
        {
            return false;
        }
        if (!hField.text.Equals("o") && !hField.text.Equals("O"))
        {
            return false;
        }
        if (!iField.text.Equals("c") && !iField.text.Equals("C"))
        {
            return false;
        }
        if (!jField.text.Equals("g") && !jField.text.Equals("G"))
        {
            return false;
        }
        if (!kField.text.Equals("p") && !kField.text.Equals("P"))
        {
            return false;
        }
        //if (!lField.text.Equals("z") && !lField.text.Equals("Z"))
        //{
        //    return false;
        //}
        if (!mField.text.Equals("a") && !mField.text.Equals("A"))
        {
            return false;
        }
        //if (!nField.text.Equals("f") && !nField.text.Equals("F"))
        //{
        //    return false;
        //}
        if (!oField.text.Equals("m") && !oField.text.Equals("M"))
        {
            return false;
        }
        //if (!pField.text.Equals("v") && !pField.text.Equals("V"))
        //{
        //    return false;
        //}
        //if (!qField.text.Equals("w") && !qField.text.Equals("W"))
        //{
        //    return false;
        //}
        if (!rField.text.Equals("y") && !rField.text.Equals("Y"))
        {
            return false;
        }
        if (!sField.text.Equals("b") && !sField.text.Equals("B"))
        {
            return false;
        }
        //if (!tField.text.Equals("j") && !tField.text.Equals("J"))
        //{
        //    return false;
        //}
        if (!uField.text.Equals("n") && !uField.text.Equals("N"))
        {
            return false;
        }
        //if (!vField.text.Equals("q") && !vField.text.Equals("Q"))
        //{
        //    return false;
        //}
        if (!wField.text.Equals("r") && !wField.text.Equals("R"))
        {
            return false;
        }
        if (!xField.text.Equals("e") && !xField.text.Equals("E"))
        {
            return false;
        }
        //if (!yField.text.Equals("x") && !yField.text.Equals("X"))
        //{
        //    return false;
        //}
        //if (!zField.text.Equals("k") && !zField.text.Equals("K"))
        //{
        //    return false;
        //}
        return true;
    }

    public void OnSubmit()
    {
        if (checkInputs())
        {
            PlayerPrefs.SetInt("P" + puzzleNumber, 1);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 60);
            PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
            SceneManager.LoadScene("MazeScene");
        }
        else
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 10);
            PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
            SceneManager.LoadScene("MazeScene");
        }
    }
}
