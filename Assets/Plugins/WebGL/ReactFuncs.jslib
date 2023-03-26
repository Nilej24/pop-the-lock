mergeInto(LibraryManager.library, {
	TestFunc: function (text1, text2) {
		window.dispatchReactUnityEvent("TestFunc", UTF8ToString(text1), UTF8ToString(text2));
	},
});
