using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class create_Coin : MonoBehaviour
{
    public static int Coin;
    public static int boll;
    public static int boll_count;
    public Camera MainCamera;
    private int Boll;
    public Transform target; // �Ǐ]����Ώ�
    public float speed = 5f; // �ړ��X�s�[�h
    public static bool Camera_Bool;
    public static int count;
    public static bool JP_Count = true;
    public AudioSource audioSource;
    public AudioClip JP_BGM;
    public AudioClip Defalut_BGM;
    public AudioClip SE1;
    void Start()
    {
        PlayBGM(Defalut_BGM);
    }
    // ���̃I�u�W�F�N�g�����̃I�u�W�F�N�g�ɐG�ꂽ���ɌĂ΂��
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin++;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("boll"))
        {
            
            boll++;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (boll >= 5 && boll > 0)
        {
            count = 5;
            Camera_Bool = true;
            boll_count = 1;
        }
        else
        if(boll<=10 && boll>5)
        {
            JP_Count=true;
            Debug.Log("Boll>=5");
        }

        if (Camera_Bool)
        {
            if ((!clistion.Atri || !clostin_.Atri || !clostion_200.Atri) && !Panel_controall.Camera_shop_Controller)
            {
                // �W���b�N�|�b�g�ɐi��
                // �J�������^�[�Q�b�g�̈ʒu�ɒǏ]������

                // �ɂ₩�Ƀ^�[�Q�b�g�̈ʒu�ɋ߂Â��i���`��ԁj
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
        StartCoroutine(Defalout_state());
        StartCoroutine(Coin_ceack());
    }
    IEnumerator Coin_ceack()
    {
        if(boll>=5)
        {
            boll -= 5;
            StartCoroutine(FadeOutAndIn(audioSource, JP_BGM, 0.2f));
            Debug.Log(boll);
            
            yield return new WaitForSeconds(10f);
            Camera_Bool = false;
            Debug.Log("�W���b�N�|�b�g�s���J����OF");
        }
    }
    IEnumerator FadeOutAndIn(AudioSource audioSource, AudioClip bgmClip, float fadeDuration)
    {
        float startVolume = 0.2f;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }
        // ���ʂ����S��0�ɂ���
        audioSource.volume = 0;
        audioSource.clip = bgmClip; 
        
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }
        audioSource.Play();
    }

    public void PlayBGM(AudioClip bgmClip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // �Đ�����BGM���~
        }
        audioSource.clip = bgmClip;
        audioSource.Play(); // �V����BGM���Đ�
    }

    IEnumerator Defalout_state()
    {
        if ((clistion.Atri || clostin_.Atri || clostion_200.Atri) && !Panel_controall.Camera_shop_Controller)
        {
            // �J�������^�[�Q�b�g�̈ʒu�ɒǏ]������
            Vector3 targetPosition = new Vector3(0, 18.6f, -14.77f);

            // �ɂ₩�Ƀ^�[�Q�b�g�ɋ߂Â��i���`��ԁj
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, speed * Time.deltaTime);
        }
        if ((clistion.BGM || clostin_.BGM || clostion_200.BGM) && !Panel_controall.Camera_shop_Controller)
        {
            audioSource.PlayOneShot(SE1);
            Debug.Log("SE");
            StartCoroutine(FadeOutAndIn(audioSource, Defalut_BGM, 0.2f));
            yield return new WaitForSeconds(10f);
        }
    }
}