# vkui-uwp
Стили и иконки VKUI для платформы UWP.

# Подключение VKUI к проекту.
Добавьте ссылку на проект VK.UI.UWP. Затем в файле **App.xaml** добавьте следующий код:

``` xaml
<Application.Resources>
  <ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
      <ResourceDictionary Source="ms-appx:///VK.UI.UWP/Colors.xaml"/>
      <ResourceDictionary Source="ms-appx:///VK.UI.UWP/Styles.xaml"/>
    </ResourceDictionary.MergedDictionaries>
  </ResourceDictionary>
</Application.Resources>
```
