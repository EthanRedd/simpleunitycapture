using UnityEngine;
using System.Collections;

public class ScreenRecorder : MonoBehaviour{
	
	public string path				= "C:/Screenshots//SET THIS TO SOME VALID PATH
	public	string frameNameBase	= "capture";//SET BASE FILE NAME FOR EACH FRAME
	public	string recordButton		= "Fire 2";//SET BUTTON TO TOGGLE RECORDING
	
	private string frameName		= "";
	private bool 	recording 		= false;
	private int	counter				= 0;
	
	//RESET COUNTER
	void reset(){
		counter = 0;
	}
	
	//SET RECORDING STATUS
	void setRecording(bool b){
		recording = b;
		if(b){
			Debug.Log("Started recording!");
		}
		else{
			Debug.Log("Stopped recording.");
			reset();
		}
	}
	
	//TOGGLE REECORDING STATUS
	void toggleRecording(){
		setRecording(!recording);
	}
	
	//SAVE SCREENSHOT/INCREMENT NAME
	void saveScreenshot(){
		frameName = path + "/" + frameNameBase + counter + ".png";
		Application.CaptureScreenshot(frameName);
		counter++;
	}
	
	void Update(){
		if(Input.GetButtonDown(recordButton)){
			toggleRecording();
		}
	}
	
	void LateUpdate(){
		//IF CURRENTLY RECORDING, SAVE CURRENT FRAME
		if(recording){
			saveScreenshot();
		}
	}
}
