(function ($) {
	"use strict";
	LoadEditor();
})(jQuery);

function LoadEditor() {
	var editorElements = document.querySelectorAll('.editor');

	editorElements.forEach(function (editorElement) {
		if (!editorElement.getAttribute('data-ckeditor-initialized')) {
			CKEDITOR.replace(editorElement);
			editorElement.setAttribute('data-ckeditor-initialized', 'true');
		}
	});
}

