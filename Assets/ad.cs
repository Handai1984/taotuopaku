using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using Umeng;

public class ad : MonoBehaviour
{
	private InterstitialAd interstitial;
	private BannerView bannerView;
	private string testDev;
	// Use this for initialization

	void Awake() {
		#if UNITY_ANDROID
//		string appId = "ca-app-pub-3940256099942544~3347511713";
		string appId = "ca-app-pub-6215391817845489~9334131717";
		string umId = "5ad6b2def43e48736400013f";
		testDev = "e92f3f152355cf85f59a5c2d2d9a87e2";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3940256099942544~1458002511";
		string umId = "5ad6b2def43e48736400013f";
		testDev = "e92f3f152355cf85f59a5c2d2d9a87e2";
		#else
		string appId = "unexpected_platform";
		#endif

		//init umsdk
		GA.StartWithAppKeyAndChannelId (umId, "andriod");
		GA.ProfileSignIn ("hello,world");
		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize (appId);
		RequestInterstitial ();
		RequestBanner ();
	
	}


		//banner init
		private void RequestBanner ()
		{
		#if UNITY_ANDROID
//		string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		string adUnitId = "ca-app-pub-6215391817845489/6707968376";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/2934735716";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView (adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ()
		.AddTestDevice(testDev)
		.Build ();

		// Load the banner with the request.
		bannerView.LoadAd (request);

		}


		//interstitial init
		private void RequestInterstitial ()
		{
		#if UNITY_ANDROID
//		string adUnitId = "ca-app-pub-3940256099942544/1033173712";
		string adUnitId = "ca-app-pub-6215391817845489/1260324287";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		this.interstitial = new InterstitialAd (adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ()
		.AddTestDevice(testDev)
		.Build ();
		// Load the interstitial with the request.
		this.interstitial.LoadAd (request);
		}

		//展示插屏
		public void ShowInter ()
		{
		if (this.interstitial.IsLoaded ()) {
		this.interstitial.Show ();
		} else {
		RequestInterstitial ();
		}
		}

		//展示横幅
		public void ShowBanner() {

		bannerView.Show ();
		}


		}