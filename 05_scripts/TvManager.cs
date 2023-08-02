using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using Slider = UnityEngine.UI.Slider;

public class TvManager : MonoBehaviour
{
    //this will be used to store clips to play
    public VideoClip[] videoClips;

    //reference to the videoplayer
    public VideoPlayer videoPlayer;

    //slider to seek the video
    public Slider SeekerSlider;
    bool isDragging = false;

    public Button PausePlayBtn;
    public Button BackBtn;


    private void Start()
    {
        PausePlayBtn.onClick.AddListener(PausePlayToggle);
        BackBtn.onClick.AddListener(Back);
    }

    private void Update()
    {
        if(videoPlayer.frameCount > 0 && !isDragging)
        {
            SeekerSlider.value = (float)(videoPlayer.time / videoPlayer.clip.length);
        }
    }

    //seek video when slider is draged
    public void DragSlider()
    {
        isDragging = true;
    }
    //when Drag is ended set the video to slider value
    public void EndDragSlider()
    {
        SeekVideo(SeekerSlider.value);
        isDragging = false;
    }

    //seek video when slider value is changed
    public void SetFrameBySlider()
    {
        videoPlayer.Pause();
        SeekVideo(SeekerSlider.value);
        videoPlayer.Play();
    }

    //seek video to value
    void SeekVideo(float value)
    {
        videoPlayer.time = videoPlayer.clip.length * value;
    }

    //player video when clicked
    public void VideoOnBtn(int index)
    {
        videoPlayer.clip = videoClips[index];
        videoPlayer.Play();
    }

    //back button in video player
    public void Back()
    {
        videoPlayer.Stop();
        videoPlayer.clip = null;
    }

    //pause and play button for videoplayer
    public void PausePlayToggle()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }

}
