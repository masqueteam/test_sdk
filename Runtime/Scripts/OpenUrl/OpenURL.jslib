<<<<<<< HEAD
var plugin = {
    OpenURL : function(url)
    {
      url = Pointer_stringify(url);
      if (confirm("Open URL "+url)) {
        window.open(url,'_self');
      } else {
      }
    },
};
mergeInto(LibraryManager.library, plugin);
=======
var plugin = {
    OpenURL : function(url)
    {
      url = Pointer_stringify(url);
      if (confirm("Open URL "+url)) {
        window.open(url,'_self');
      } else {
      }
    },
};
mergeInto(LibraryManager.library, plugin);
>>>>>>> aca2d79 (-init)
