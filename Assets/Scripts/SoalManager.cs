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
    public Text txtPenilaian;
    public GameObject panel;
    public GameObject imgPenilaian, imgHasil;
    public Text txtHasil,txtNomor;
    int indexSoal;
    int maxSoal;
    bool ambilsoal;
    char kunciJawaban;

    bool isHasil;
    private float durasi;
    public float durasiPenilaian;

    int jawabanBenar, jawabanSalah;
    float nilai;
    int nomorSoal;
    public Image soalGambar;

    void Start()
    {
        durasi = durasiPenilaian;
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
            nomorSoal++;
            txtNomor.text = "Soal " + nomorSoal;
            txtNomor.alignment = TextAnchor.MiddleCenter;
        }
    }

    public void Opsi(string opsiHuruf)
    {
        checkJawaban(opsiHuruf[0]);

        if(indexSoal == maxSoal - 1)
        {
            isHasil = true;
        }
        else
        {
            indexSoal++;
            ambilsoal = true;
        }

        panel.SetActive(true);
    }

    private float HitungNilai()
    {
        return nilai = (float)jawabanBenar / maxSoal * 100;
    }

    private void checkJawaban(char huruf)
    {
        string penilaian;

        if (huruf.Equals(kunciJawaban))
        {
            penilaian = "Benar";
            jawabanBenar++;
        }
        else
        {
            penilaian = "Salah";
            jawabanSalah++;
        }

        txtPenilaian.text = penilaian;
        txtPenilaian.alignment = TextAnchor.MiddleCenter;
    }

    void Update()
    {
        if (panel.activeSelf)
        {
            durasiPenilaian -= Time.deltaTime;

            if (isHasil)
            {
                imgPenilaian.SetActive(true);
                imgHasil.SetActive(false);

                if(durasiPenilaian <= 0)
                {
                    txtHasil.text = "Jumlah Benar : " + jawabanBenar + "\nJawaban Salah : " + jawabanSalah + "\n\nSkor Akhir : " + HitungNilai();
                    txtHasil.alignment = TextAnchor.MiddleLeft;

                    imgPenilaian.SetActive(false);
                    imgHasil.SetActive(true);

                    durasiPenilaian = 0;
                }
            }
            else
            {
                imgPenilaian.SetActive(true);
                imgHasil.SetActive(false);

                if (durasiPenilaian <= 0)
                {
                    panel.SetActive(false);
                    durasiPenilaian = durasi;

                    TampilkanSoal();
                }
            }
        }
    }
}
