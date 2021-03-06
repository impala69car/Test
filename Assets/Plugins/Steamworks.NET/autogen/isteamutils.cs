// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2014 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamUtils {
		// return the number of seconds since the user
		public static uint GetSecondsSinceAppActive() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceAppActive();
		}

		public static uint GetSecondsSinceComputerActive() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceComputerActive();
		}

		// the universe this client is connecting to
		public static EUniverse GetConnectedUniverse() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetConnectedUniverse();
		}

		// Steam server time - in PST, number of seconds since January 1, 1970 (i.e unix time)
		public static uint GetServerRealTime() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetServerRealTime();
		}

		// returns the 2 digit ISO 3166-1-alpha-2 format country code this client is running in (as looked up via an IP-to-location database)
		// e.g "US" or "UK".
		public static string GetIPCountry() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetIPCountry();
		}

		// returns true if the image exists, and valid sizes were filled out
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageSize(iImage, out pnWidth, out pnHeight);
		}

		// returns true if the image exists, and the buffer was successfully filled out
		// results are returned in RGBA format
		// the destination buffer size should be 4 * height * width * sizeof(char)
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageRGBA(iImage, pubDest, nDestBufferSize);
		}

		// returns the IP of the reporting server for valve - currently only used in Source engine games
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCSERIPPort(out unIP, out usPort);
		}

		// return the amount of battery power left in the current system in % [0..100], 255 for being on AC power
		public static byte GetCurrentBatteryPower() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCurrentBatteryPower();
		}

		// returns the appID of the current process
		public static AppId_t GetAppID() {
			InteropHelp.TestIfAvailableClient();
			return (AppId_t)NativeMethods.ISteamUtils_GetAppID();
		}

		// Sets the position where the overlay instance for the currently calling game should show notifications.
		// This position is per-game and if this function is called from outside of a game context it will do nothing.
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetOverlayNotificationPosition(eNotificationPosition);
		}

		// API asynchronous call results
		// can be used directly, but more commonly used via the callback dispatch API (see steam_api.h)
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsAPICallCompleted(hSteamAPICall, out pbFailed);
		}

		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallFailureReason(hSteamAPICall);
		}

		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallResult(hSteamAPICall, pCallback, cubCallback, iCallbackExpected, out pbFailed);
		}

		// this needs to be called every frame to process matchmaking results
		// redundant if you're already calling SteamAPI_RunCallbacks()
		public static void RunFrame() {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_RunFrame();
		}

		// returns the number of IPC calls made since the last time this function was called
		// Used for perf debugging so you can understand how many IPC calls your game makes per frame
		// Every IPC call is at minimum a thread context switch if not a process one so you want to rate
		// control how often you do them.
		public static uint GetIPCCallCount() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetIPCCallCount();
		}

		// API warning handling
		// 'int' is the severity; 0 for msg, 1 for warning
		// 'const char *' is the text of the message
		// callbacks will occur directly after the API function is called that generated the warning or message
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetWarningMessageHook(pFunction);
		}

		// Returns true if the overlay is running & the user can access it. The overlay process could take a few seconds to
		// start & hook the game process, so this function will initially return false while the overlay is loading.
		public static bool IsOverlayEnabled() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsOverlayEnabled();
		}

		// Normally this call is unneeded if your game has a constantly running frame loop that calls the
		// D3D Present API, or OGL SwapBuffers API every frame.
		//
		// However, if you have a game that only refreshes the screen on an event driven basis then that can break
		// the overlay, as it uses your Present/SwapBuffers calls to drive it's internal frame loop and it may also
		// need to Present() to the screen any time an even needing a notification happens or when the overlay is
		// brought up over the game by a user.  You can use this API to ask the overlay if it currently need a present
		// in that case, and then you can check for this periodically (roughly 33hz is desirable) and make sure you
		// refresh the screen with Present or SwapBuffers to allow the overlay to do it's work.
		public static bool BOverlayNeedsPresent() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BOverlayNeedsPresent();
		}
#if ! _PS3
		// Asynchronous call to check if an executable file has been signed using the public key set on the signing tab
		// of the partner site, for example to refuse to load modified executable files.
		// The result is returned in CheckFileSignature_t.
		//   k_ECheckFileSignatureNoSignaturesFoundForThisApp - This app has not been configured on the signing tab of the partner site to enable this function.
		//   k_ECheckFileSignatureNoSignaturesFoundForThisFile - This file is not listed on the signing tab for the partner site.
		//   k_ECheckFileSignatureFileNotFound - The file does not exist on disk.
		//   k_ECheckFileSignatureInvalidSignature - The file exists, and the signing tab has been set for this file, but the file is either not signed or the signature does not match.
		//   k_ECheckFileSignatureValidSignature - The file is signed and the signature is valid.
		public static SteamAPICall_t CheckFileSignature(string szFileName) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUtils_CheckFileSignature(szFileName);
		}
#endif
#if _PS3
		public static void PostPS3SysutilCallback(ulong status, ulong param, IntPtr userdata) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_PostPS3SysutilCallback(status, param, userdata);
		}

		public static bool BIsReadyToShutdown() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BIsReadyToShutdown();
		}

		public static bool BIsPSNOnline() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BIsPSNOnline();
		}

		// Call this with localized strings for the language the game is running in, otherwise default english
		// strings will be used by Steam.
		public static void SetPSNGameBootInviteStrings(string pchSubject, string pchBody) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetPSNGameBootInviteStrings(pchSubject, pchBody);
		}
#endif
		// Activates the Big Picture text input dialog which only supports gamepad input
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_ShowGamepadTextInput(eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText);
		}

		// Returns previously entered text & length
		public static uint GetEnteredGamepadTextLength() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetEnteredGamepadTextLength();
		}

		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText) {
			InteropHelp.TestIfAvailableClient();
			IntPtr pchText2 = Marshal.AllocHGlobal((int)cchText);
			bool ret = NativeMethods.ISteamUtils_GetEnteredGamepadTextInput(pchText2, cchText);
			pchText = ret ? InteropHelp.PtrToStringUTF8(pchText2) : null;
			Marshal.FreeHGlobal(pchText2);
			return ret;
		}

		// returns the language the steam client is running in, you probably want ISteamApps::GetCurrentGameLanguage instead, this is for very special usage cases
		public static string GetSteamUILanguage() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSteamUILanguage();
		}

		// returns true if Steam itself is running in VR mode
		public static bool IsSteamRunningInVR() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsSteamRunningInVR();
		}
	}
}