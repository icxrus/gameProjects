using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading;

namespace AudioHelper.AudioControl
{
    public class BackgroundMusicController : MonoBehaviour
    {
        public IList<AudioClipAdvanced> SourceAsset;
        public AudioClipAdvanced[] SourceAssetArray = new AudioClipAdvanced[0];
        public AudioSource SourceComponent;

        // The currently playing track, represented by an integer.
        private int NowPlaying = 0;
        // The ammount of tracks in the playlist or array.
        private int Count;
        //The track to start with. Default is 0.
        //Used with "InitializePlaylist(int TrackNumber)"
        public int StartFrom = 0;
        // The total length of the current track.
        private float MaxTime;
        // Tells the thread if playback has already begun.
        private bool PlaylistInitialized = false;

        // Begins playing from the playlist/array, in order.
        public void InitializePlaylist()
        {
            if (SourceComponent.isPlaying)
            {
                PlaylistInitialized = false;
                SourceComponent.Stop();
            }
            NowPlaying = 0;
            SourceAsset = SourceAssetArray;
            MaxTime = SourceAsset[NowPlaying].source.length;
            Count = SourceAssetArray.Count<AudioClipAdvanced>();

            SourceComponent.clip = SourceAsset[NowPlaying].source;
            SourceComponent.loop = SourceAsset[NowPlaying].Loop;
            SourceComponent.Play();

            PlaylistInitialized = true;
        }

        // Begins playing from the playlist/array, in order.
        //The song from the array to start with. Default is 0 (first track).
        public void InitializePlaylist(int TrackNumber)
        {
            if (SourceComponent.isPlaying)
            {
                PlaylistInitialized = false;
                SourceComponent.Stop();
            }
            NowPlaying = TrackNumber;
            SourceAsset = SourceAssetArray;
            MaxTime = SourceAsset[NowPlaying].source.length;
            Count = SourceAssetArray.Count<AudioClipAdvanced>();

            SourceComponent.clip = SourceAsset[NowPlaying].source;
            SourceComponent.loop = SourceAsset[NowPlaying].Loop;
            SourceComponent.Play();

            PlaylistInitialized = true;
        }

        // Checks if the song is over, and begins the next song if it is.
        public void Advance()
        {
            if (SourceComponent.loop || NowPlaying == Count) { return; } // Alternatively, inside a loop, use 'break;' to cancel or exit the playlist completely.
            else if (SourceComponent.time >= MaxTime)
            {
                SourceComponent.Stop();
                NowPlaying++;
                SourceComponent.clip = SourceAsset[NowPlaying].source;
                SourceComponent.loop = SourceAsset[NowPlaying].Loop;
                SourceComponent.Play();
            }
        }

        void Start()
        {
            // Tells the thread to start on a certain track, if specified.
            if (StartFrom <= 0) { InitializePlaylist(); } else { InitializePlaylist(StartFrom); }
        }

        void Update()
        {
            if (PlaylistInitialized)
            {
                try
                {
                    Advance();
                }
                catch (Exception err)
                {
                    Debug.LogException(err);
                }
            }
        }
    }
}
