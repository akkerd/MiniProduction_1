// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


// this shader showcases some methods for transparency and blending

Shader "Custom/transparencyshader" {


properties { // this is where you define your varaibles for the first time

_Color ("Color",Color)=(0,0,0,0) // This is how a variable needs to be defined if its going to be used from unity.
_MainTexture("Main Color (RGB) Hello",2D) = "white"{}
_ScanTexture("Main Color (RGB) Hello2",2D) = "white"{}


  }
  SubShader{



       Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}  
       


      
  pass{


  Zwrite Off // "on" for opaque objects, "off" for transparent objects
// Blend one one  // additive blend, this will ignore your alpha channels and do additive blend between objects.
  Blend One OneMinusSrcAlpha // This assumes premultiplied aplha. This allows you to control  if you need to use the alpha channel

   CGPROGRAM 





  
  #pragma vertex vers
  #pragma fragment frag 

  //variables
  uniform float4 _Color; // first color  - float4 because it have a RED,GREEN,BLUE and ALPHA channel.
  sampler2D _MainTexture;
  sampler2D _ScanTexture;





  // structs

  // this struct will be all the variables you need in your vertex function
  struct vertexInput {
	  float4 vert : POSITION;
	  float2 uv : TEXCOORD0;
  };
  // this struct is what you send to your frag function from your vertex function. The "output" of your vertex function 
  struct vertexOutput{
  float4 pos : SV_POSITION; 
  float2 uv : TEXCOORD0;
  };



  // The ONLY thing the vert function does is convert the object from object space to clipspace/projection.

  vertexOutput vers(vertexInput v){ 
  // This means that the object position can now be accessed as v.vert
	  v.uv.y = 1 - v.uv.y;
	  v.uv.x = 1 - v.uv.x;
  vertexOutput o; // again, this is maybe easier understood if read as: o = vertexOutput
  o.pos = UnityObjectToClipPos(v.vert); // This transform from object space to clip space. This was formerly known as mul(UNITY_MATRIX_MVP,v.)
  o.uv = v.uv + 0.008*cos(_Time);
  
  // again o.pos is the position declared in the vertexOutput struct.
  return o; //returns the entire struct vertexOutput, in this case the only thing o contains is the position in clip space.

  }



  
  float4 frag(vertexOutput i) : COLOR

  {
	  
	 // if ( tex2D(_MainTexture,i.uv).z > 0.97 && tex2D(_MainTexture,i.uv).x > 0.97 && tex2D(_MainTexture,i.uv).y > 0.97)discard;
  if (tex2D(_ScanTexture, i.uv  +(_Time / 8)).x < 0.97 )discard;
  return  tex2D(_MainTexture, i.uv)*_Color;// Additive

  //return _Color*_Color2; // Multiplied

 // return float4(_Color * _Color.a + _Color2 * _Color2.a * (1.0f-_Color.a))/(_Color.a + _Color2.a * (1.0f-_Color.a)); // _Color over _Color2

  }



 // + 0.05*cos(_Time)


  ENDCG

  }
  }
}
