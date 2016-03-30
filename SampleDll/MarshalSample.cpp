#include "MarshalSample.h"
#include <vector>
#include <cmath>
#include <algorithm>

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

	std::vector<unsigned char> g_buffer;

	EXPORT void SetBytes(const unsigned char *p, int size)
	{
		g_buffer.assign(p, p + size);
	}

	EXPORT int GetBytes(unsigned char *p /* out */, int size)
	{
		auto min_size = std::min<int>(size, (int)g_buffer.size());
		std::copy(g_buffer.begin(), g_buffer.begin()+min_size, p);
		return min_size;
	}

	EXPORT void SetBytesByVoidPointer(void *p, int size)
	{
		SetBytes((const unsigned char *)p, size);
	}

	EXPORT void *GetBytesPointer(int *pSize /* out */)
	{
		if (g_buffer.empty() || !pSize) {
			return nullptr;
		}

		*pSize = (int)g_buffer.size();
		return (void*)&g_buffer[0];
	}

	EXPORT int GetBytesByVoidPointer(void **p)
	{
		if (g_buffer.empty() || !p) {
			return 0;
		}
		*p = &g_buffer[0];
		return (int)g_buffer.size();
	}
}
