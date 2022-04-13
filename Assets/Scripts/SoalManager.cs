using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoalManager : MonoBehaviour
{
    public TextAsset assetSoal;

    [SerializeField] private string[] soal;

    [SerializeField] private string[,] soalBag;

    public Text txtSoal, txtOpsiA, txtOpsiB, txtOpsiC, txtOpsiD;

    int indexSoal;
    int maxSoal;
    bool ambilsoal;
    char kunciJawaban;

    void Start()
    {
        soal = assetSoal.ToString().Split('#');

        soalBag = new string[soal.Length, 6];
        maxSoal = soal.Length;
        OlahSoal();

        ambilsoal = true;
        TampilkanSoal();
        print(soalBag[2, 2]);
    }

    private void OlahSoal()
    {
        for(int i = 0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');

            for(int j=0; j < tempSoal.Length; j++)
            {
                soalBag[i, j] = tempSoal[j].Replace("\"", "");
                continue;
            }
            continue;
        }
    }

    private void TampilkanSoal()
    {
        if(indexSoal < maxSoal)
        {
            if(ambilsoal)
            {
                txtSoal.text = soalBag[indexSoal, 0];
                txtOpsiA.text = soalBag[indexSoal, 1];
                txtOpsiB.text = soalBag[indexSoal, 2];
                txtOpsiC.text = soalBag[indexSoal, 3];
                txtOpsiD.text = soalBag[indexSoal, 4];
                kunciJawaban = soalBag[indexSoal, 5][0];

                //alignment text
                txtSoal.alignment = TextAnchor.LowerLeft;
                txtOpsiA.alignment = TextAnchor.LowerLeft;
                txtOpsiB.alignment = TextAnchor.LowerLeft;
                txtOpsiC.alignment = TextAnchor.LowerLeft;
                txtOpsiD.alignment = TextAnchor.LowerLeft;

                ambilsoal = false;
            }
        }
    }

    public void Opsi(string opsiHuruf)
    {

    }

    void Update()
    {
        
    }
}
