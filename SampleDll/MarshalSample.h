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
    EXPORT float GetFloat();
    EXPORT void SetFloat(float n);
}
