(function ($) {
	"use strict";
	LoadEditor();
})(jQuery);

function LoadEditor() {
	var editorElements = document.querySelectorAll('.editor');

	editorElements.forEach(function (editorElement) {
		if (!editorElement.getAttribute('data-ckeditor-initialized')) {
			$(editorElement).summernote({
				tabsize: 2,
				height: '30vh',
				background: 'white'
			})
			editorElement.setAttribute('data-ckeditor-initialized', 'true');
		}
	});
}
