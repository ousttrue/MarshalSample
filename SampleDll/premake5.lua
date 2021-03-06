-- premake5.lua
location "build"

solution "MarshalSample"
do
    configurations { "Debug", "Release" }
    platforms { "Win64" }
end

filter "configurations:Debug"
do
    defines { "DEBUG", "_DEBUG" }
    flags { "Symbols" }
end

filter "configurations:Release"
do
    defines { "NDEBUG" }
    optimize "On"
end

filter { "platforms:Win32" }
   architecture "x32"
filter { "platforms:Win64" }
   architecture "x64"

filter {"platforms:Win32", "configurations:Debug" }
    targetdir "build/Win32/Debug"
filter {"platforms:Win32", "configurations:Release" }
    targetdir "build/Win32/Release"
filter {"platforms:Win64", "configurations:Debug" }
    targetdir "build/Win64/Debug"
filter {"platforms:Win64", "configurations:Release" }
    targetdir "build/Win64/Release"
    postbuildcommands{
        "copy Win64\\Release\\MarshalSample.dll ..\\..\\UnityMarshalSample\\Assets\\MarshalSample\\Plugins\\x86_64\\MarshalSample.dll"
    }

project "MarshalSample"
do
    --kind "ConsoleApp"
    --kind "WindowedApp"
    --kind "StaticLib"
    kind "SharedLib"
    --language "C"
    language "C++"

    flags{ 
        --"WinMain" 
    }
    files { "*.h", "*.cpp" }
    includedirs {}
    defines {
        "WIN32",
        "_WINDOWS",
        "SAMPLE_BUILD",
    }
    buildoptions { "/wd4996" }
    libdirs {}
    links {}
end

