# Session 05 - file Update and deletion

[Click here to download the lecture for this session](https://www.idrive.com/idrive/sh/sh?k=t4w2y9f3q9)


### Upcoming Tasks

  - TODO: Add an update image and remove image options

  - TODO: Vaidation of Image Upload


### HTML Helpers

An HTML Helper is just a method that returns a string. The string can represent any type of content that you want. For example, you can use HTML Helpers to render standard HTML tags like HTML \<input\> and \<img\> tags. You also can use HTML Helpers to render more complex content such as a tab strip or an HTML table of database data.

The ASP.NET MVC framework includes the following set of standard HTML Helpers (this is not a complete list):

- Html.TextBoxFor()
- Html.LabelFor()
- Html.BeginForm()
- Html.CheckBox()
- Html.DropDownList()
- Html.EndForm()
- Html.Hidden()
- Html.Password()
- Html.RadioButton()
- Html.TextArea()
- Html.TextBox()


### System.IO

System IO gives us the ability to work with the files and directories

some usefull functions from System.IO:

- Directory.Exists(_dirName);
- Directory.Create(_dirName);
- Files.Delete(_filePath);
- Files.Exists(_filePath);