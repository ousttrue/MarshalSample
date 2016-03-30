#pragma once
#ifdef SAMPLE_BUILD
#ifdef _MSC_VER
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif
#else
#define EXPORT
#endif
extern "C" {
	EXPORT void SetFloat(float n);
	EXPORT float GetFloat();

	EXPORT void SetBytesByVoidPointer(void *p, int size);
	EXPORT void SetBytes(const unsigned char *p, int size);
	EXPORT int GetBytes(unsigned char *p /* out */, int size);
	EXPORT void *GetBytesPointer(int *pSize /* out */);
	EXPORT int GetBytesByVoidPointer(void **p);
}
