#include "../UnityPluginAPI/IUnityInterface.h"

typedef void (*CALLBACK)(int result);

extern "C" int UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API GetTwo () { 
    return 2; 
}

extern "C" bool  UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API PassCallback (CALLBACK callback) { 
    if(!callback) {
        return false;
    }
    callback(5);
    return true;
 }
