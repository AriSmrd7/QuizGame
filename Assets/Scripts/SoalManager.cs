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
    public GameObject imgBenar, imgSalah;
    public GameObject panel;
    public GameObject imgPenilaian, imgHasil;
    public Text txtHasil,txtNomor;
    public GameObject imgSoal1, imgSoal2, imgSoal3, imgSoal4, imgSoal5, imgSoal6, imgSoal7, imgSoal8, imgSoal9, imgSoal10;
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

    void Start()
    {
        durasi = durasiPenilaian;
        soal = assetSoal.ToString().Split('#');

        soalBag = new string[soal.Length, 6];
        maxSoal = soal.Length;
        OlahSoal();

        ambilsoal = true;
        TampilkanSoal();
        gantiGambarSoal();
    }

    private void gantiGambarSoal()
    {
        if (nomorSoal == 1)
        {
            imgSoal1.SetActive(true);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 2)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(true);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 3)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(true);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 4)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(true);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 5)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(true);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 6)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(true);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 7)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(true);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 8)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(true);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 9)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(true);
            imgSoal10.SetActive(false);
        }
        else if (nomorSoal == 10)
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(true);
        }
        else
        {
            imgSoal1.SetActive(false);
            imgSoal2.SetActive(false);
            imgSoal3.SetActive(false);
            imgSoal4.SetActive(false);
            imgSoal5.SetActive(false);
            imgSoal6.SetActive(false);
            imgSoal7.SetActive(false);
            imgSoal8.SetActive(false);
            imgSoal9.SetActive(false);
            imgSoal10.SetActive(false);
        }
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

        if (huruf.Equals(kunciJawaban))
        {
            imgBenar.SetActive(true);
            imgSalah.SetActive(false);
            jawabanBenar++;
        }
        else
        {
            imgSalah.SetActive(true);
            imgBenar.SetActive(false);
            jawabanSalah++;
        }

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
                    txtHasil.text = "Jawaban Benar : " + jawabanBenar + "\nJawaban Salah : " + jawabanSalah + "\n\n\nSKOR AKHIR : " + HitungNilai();
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
        gantiGambarSoal();
    }
}
