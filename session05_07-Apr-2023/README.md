# Session 05 - Validation and Image Upload

[Click here to download the lecture for this session](https://www.idrive.com/idrive/sh/sh?k=t0g5a6c4s2)

## Introduction
In this lecture we will implement a CRUD on `Student Model` which uses a foreign key `CourseId`. Also we will look at form `validation` and some `validation attributes`.  Delete Confirmation

#### download the code and run it in the visual `studio code` or `Visual Studio`

#### Saving Image to folder
```csharp
//Save image to wwwroot/image
string wwwRootPath = _hostEnvironment.WebRootPath;
string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
string extension = Path.GetExtension(imageModel.ImageFile.FileName);
imageModel.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
string path = Path.Combine(wwwRootPath + "/Image/", fileName);
using (var fileStream = new FileStream(path,FileMode.Create))
{
    await imageModel.ImageFile.CopyToAsync(fileStream);
}
```
#### deleting image

```csharp
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var imageModel = await _context.Images.FindAsync(id);

    //delete image from wwwroot/image
    var imagePath = Path.Combine(_hostEnvironment.WebRootPath,"image",imageModel.ImageName);
    if (System.IO.File.Exists(imagePath))
        System.IO.File.Delete(imagePath);
    //delete the record
    _context.Images.Remove(imageModel);
    await _context.SaveChangesAsync();
    return RedirectToAction("Index");
}
```

### IFormFile
IFormFile is an interface in ASP.NET Core that represents an uploaded file. When a user uploads a file through a form on a web page, the file is sent to the server as part of an HTTP request. The IFormFile interface provides a way to access the contents of the uploaded file and its metadata, such as the file name and content type.

### FileStream
Speaking of FileStream, it is a class in the System.IO namespace that provides a way to read and write data to and from a file. It is commonly used in C# to read or write the contents of a file on disk.