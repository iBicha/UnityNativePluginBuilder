﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMake
{
	public static class XcodeInstructions
	{
		public static Instruction IOSInstallUniversalLibraries(bool enable)
		{
			return new SetInstruction()
			{
				Var = "CMAKE_IOS_INSTALL_UNIVERSAL_LIBS",
				Value = enable ? "ON" : "OFF"
			};
		}

		public static Instruction ActiveArchOnly(bool enable)
		{
			return new SetInstruction()
			{
				Var = "CMAKE_XCODE_ATTRIBUTE_ONLY_ACTIVE_ARCH",
				Value = enable ? "ON" : "OFF"
			};
		}

		public static Instruction EffectivePlatforms(bool devices, bool simulators)
		{
			return new SetInstruction()
			{
				Var = "CMAKE_XCODE_EFFECTIVE_PLATFORMS",
				Value = "\"" + string.Join(";", (devices ? "-iphoneos" : ""), (simulators ? "-iphonesimulator" : "")).Trim(';') + "\""
			};
		}

	}
}