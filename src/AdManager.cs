using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using admob;
public class AdManager : MonoBehaviour {

	public string bannerId, videoId,elvideo;
	public static AdManager Instance{ set; get;}
	public Text Energy_Points,getFree;
	public Canvas Remind;
	public int energy;
	// Use this for initialization
	public void Start () {
		 
		Instance = this;
		Admob.Instance ().initAdmob (bannerId,videoId);
		Admob.Instance ().loadInterstitial();
	}

	 
	public void ShowBanner()
	{
		Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.BOTTOM_CENTER, 5);
	}

	public void ShowVideo()
	{
		if (Admob.Instance ().isInterstitialReady()) {
			
			Admob.Instance ().showInterstitial ();

		}

	}
	public void ElVideo()
	{
		
			Admob.Instance ().showRewardedVideo();
			
	}

}
