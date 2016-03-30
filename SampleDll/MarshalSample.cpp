#include "MarshalSample.h"

extern "C" {
	float g_float = 0.0f;

	EXPORT float GetFloat()
	{
		return g_float;
	}

	EXPORT void SetFloat(float n)
	{
		g_float = n;
	}
}
