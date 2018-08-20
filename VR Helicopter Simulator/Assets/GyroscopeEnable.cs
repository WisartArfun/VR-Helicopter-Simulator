#if UNITY_EDITOR
	
	using UnityEngine; 
	using System.Collections;
	
	public class GyroscopeEnable : MonoBehaviour
	{    
	private Gyroscope gyro;

		void Start ()
		{
			if (SystemInfo.supportsGyroscope) {
				gyro = Input.gyro;
				gyro.enabled = true;
			}
		}
	}
	
	#endif

//  https://answers.unity.com/questions/985989/google-cardboard-not-move-the-camera-when-im-using.html
