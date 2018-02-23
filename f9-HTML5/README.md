#### contenteditable copy plain text
* All browses
    ```js
    document.querySelector("div[contenteditable]").addEventListener("paste", function(e) {
        e.preventDefault();
        var text = e.clipboardData.getData("text/plain");
        document.execCommand("insertHTML", false, text);
    });
    ```
* only chrome
    ```html
    <div contenteditable="plaintext-only"></div>
    ```
