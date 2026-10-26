/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rush.Chocology.Audio
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "MusicManager")]
    public class MusicManager : MonoBehaviour
    {
        private static global::Rush.Chocology.Audio.MusicManager s_Instance;
        public static global::Rush.Chocology.Audio.MusicManager Instance { get => s_Instance; set => s_Instance = value; }

        private AudioSource m_AudioMusic;
        [UnityEngine.Serialization.FormerlySerializedAs("listBgMusic")]
        [UnityEngine.SerializeField]
        private List<AudioClip> m_ListBgMusic;
        public global::System.Collections.Generic.List<global::UnityEngine.AudioClip> ListBgMusic { get => m_ListBgMusic; set => m_ListBgMusic = value; }

        private void Awake()
        {
            s_Instance = this;
            DontDestroyOnLoad(this);
            m_AudioMusic = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.AudioSource>(this);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void PlayMusicBG() => PlayMusicBGInternal();
        private void PlayMusicBGInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsMusic)
            {
                if (m_AudioMusic.clip == null)
                {
                    int k = Random.Range(0, m_ListBgMusic.Count);
                    Debug.Log("random play " + k);
                    m_AudioMusic.clip = m_ListBgMusic[k];
                    m_AudioMusic.loop = true;
                    m_AudioMusic.Play();
                }
                else
                {
                    m_AudioMusic.Play();
                }
            }
        }

        public void StopMusicBG() => StopMusicBGInternal();
        private void StopMusicBGInternal()
        {
            m_AudioMusic.Stop();
        }
    }
}
