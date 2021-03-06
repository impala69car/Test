// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2014 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamClient {
		// Creates a communication pipe to the Steam client
		public static HSteamPipe CreateSteamPipe() {
			InteropHelp.TestIfAvailableClient();
			return (HSteamPipe)NativeMethods.ISteamClient_CreateSteamPipe();
		}

		// Releases a previously created communications pipe
		public static bool BReleaseSteamPipe(HSteamPipe hSteamPipe) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_BReleaseSteamPipe(hSteamPipe);
		}

		// connects to an existing global user, failing if none exists
		// used by the game to coordinate with the steamUI
		public static HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe) {
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamClient_ConnectToGlobalUser(hSteamPipe);
		}

		// used by game servers, create a steam user that won't be shared with anyone else
		public static HSteamUser CreateLocalUser(out HSteamPipe phSteamPipe, EAccountType eAccountType) {
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamClient_CreateLocalUser(out phSteamPipe, eAccountType);
		}

		// removes an allocated user
		public static void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_ReleaseUser(hSteamPipe, hUser);
		}

		// retrieves the ISteamUser interface associated with the handle
		public static IntPtr GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUser(hSteamUser, hSteamPipe, pchVersion);
		}

		// retrieves the ISteamGameServer interface associated with the handle
		public static IntPtr GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamGameServer(hSteamUser, hSteamPipe, pchVersion);
		}

		// set the local IP and Port to bind to
		// this must be set before CreateLocalUser()
		public static void SetLocalIPBinding(uint unIP, ushort usPort) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_SetLocalIPBinding(unIP, usPort);
		}

		// returns the ISteamFriends interface
		public static IntPtr GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamFriends(hSteamUser, hSteamPipe, pchVersion);
		}

		// returns the ISteamUtils interface
		public static IntPtr GetISteamUtils(HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUtils(hSteamPipe, pchVersion);
		}

		// returns the ISteamMatchmaking interface
		public static IntPtr GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMatchmaking(hSteamUser, hSteamPipe, pchVersion);
		}

		// returns the ISteamMatchmakingServers interface
		public static IntPtr GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMatchmakingServers(hSteamUser, hSteamPipe, pchVersion);
		}

		// returns the a generic interface
		public static IntPtr GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamGenericInterface(hSteamUser, hSteamPipe, pchVersion);
		}

		// returns the ISteamUserStats interface
		public static IntPtr GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUserStats(hSteamUser, hSteamPipe, pchVersion);
		}

		// returns the ISteamGameServerStats interface
		public static IntPtr GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamGameServerStats(hSteamuser, hSteamPipe, pchVersion);
		}

		// returns apps interface
		public static IntPtr GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamApps(hSteamUser, hSteamPipe, pchVersion);
		}

		// networking
		public static IntPtr GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamNetworking(hSteamUser, hSteamPipe, pchVersion);
		}

		// remote storage
		public static IntPtr GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamRemoteStorage(hSteamuser, hSteamPipe, pchVersion);
		}

		// user screenshots
		public static IntPtr GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamScreenshots(hSteamuser, hSteamPipe, pchVersion);
		}

		// this needs to be called every frame to process matchmaking results
		// redundant if you're already calling SteamAPI_RunCallbacks()
		public static void RunFrame() {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_RunFrame();
		}

		// returns the number of IPC calls made since the last time this function was called
		// Used for perf debugging so you can understand how many IPC calls your game makes per frame
		// Every IPC call is at minimum a thread context switch if not a process one so you want to rate
		// control how often you do them.
		public static uint GetIPCCallCount() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetIPCCallCount();
		}

		// API warning handling
		// 'int' is the severity; 0 for msg, 1 for warning
		// 'const char *' is the text of the message
		// callbacks will occur directly after the API function is called that generated the warning or message
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_SetWarningMessageHook(pFunction);
		}

		// Trigger global shutdown for the DLL
		public static bool BShutdownIfAllPipesClosed() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_BShutdownIfAllPipesClosed();
		}
#if _PS3
		public static IntPtr GetISteamPS3OverlayRender() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamPS3OverlayRender();
		}
#endif
		// Expose HTTP interface
		public static IntPtr GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamHTTP(hSteamuser, hSteamPipe, pchVersion);
		}

		// Exposes the ISteamUnifiedMessages interface
		public static IntPtr GetISteamUnifiedMessages(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUnifiedMessages(hSteamuser, hSteamPipe, pchVersion);
		}

		// Exposes the ISteamController interface
		public static IntPtr GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamController(hSteamUser, hSteamPipe, pchVersion);
		}

		// Exposes the ISteamUGC interface
		public static IntPtr GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUGC(hSteamUser, hSteamPipe, pchVersion);
		}

		// returns app list interface, only available on specially registered apps
		public static IntPtr GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamAppList(hSteamUser, hSteamPipe, pchVersion);
		}

		// Music Player
		public static IntPtr GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMusic(hSteamuser, hSteamPipe, pchVersion);
		}

		// Music Player Remote
		public static IntPtr GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMusicRemote(hSteamuser, hSteamPipe, pchVersion);
		}
	}
}