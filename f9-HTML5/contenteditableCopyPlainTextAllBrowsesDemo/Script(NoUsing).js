// Code goes here
// var el = document.querySelector("div[contenteditable]");
// // if(el){
	// el.addEventListener("paste", function(e) {
          // e.preventDefault ? e.preventDefault() : (e.returnValue = false);
          // var text = e.clipboardData.getData("text/plain");
          // document.execCommand("insertHTML", false, text);
      // });
// }

// $(document).ready(function(){
		var editable = document.querySelector("div[contenteditable]");
		editable.addEventListener('paste', function(e){
			e.preventDefault ? e.preventDefault() : (e.returnValue = false);
			if(e.clipboardData && e.clipboardData.getData) {
				var pastedText = "";
				if (window.clipboardData && window.clipboardData.getData) { // IE
					pastedText = window.clipboardData.getData('Text');
				} 
				// else if (e.clipboardData && e.clipboardData.getData) {
					// pastedText = e.clipboardData.getData('text/plain');
				// }

				document.execCommand("insertHTML", false, pastedText);
			}
			else{
				alert('Not paste object!');
			}
		});
        //editable.addEventListener('paste', pasteHandler, false);
// });
