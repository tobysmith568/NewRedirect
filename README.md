# NewRedirect

Redirects users to webpages where they can create new resources.

### Example

A GET request to
```
https://newredirect.azurewebsites.net/api/Redirect?key=doc
```
Will redirect you to
```
https://docs.google.com/document/u/0/create
```
Which is the url for a new Google doc.

### Why? (Browser Search Engine)

This tool is only really useful when it is set up as a search engine in your web browser.

Most browsers allow you to set up custom search engines which they will use when your search is prefixed with a specific term.

This functionality, along with this repo, allows you to configure your browser so that typing
```
new doc
```
opens up a new Google Doc. For Example

#### Chrome

![Chrome Instruction 1](media/Chrome1.png)
![Chrome Instruction 2](media/Chrome2.png)
![Chrome Instruction 3](media/Chrome3.png)

### Currently Supported Redirects
(Feel free to PR-in more!)

| Key   | URL                                             |
|-------|-------------------------------------------------|
| doc   | https://docs.google.com/document/u/0/create     |
| sheet | https://docs.google.com/spreadsheets/u/0/create |
