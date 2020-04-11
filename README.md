# vkui-uwp
Стили и иконки VKUI для платформы UWP.

# Подключение VKUI к проекту.
Добавьте ссылку на проект VK.VKUI. Затем в файле **App.xaml** добавьте следующий код:

``` xaml
<Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="ms-appx:///VK.VKUI/VKPalette.xaml"/>
                <ResourceDictionary Source="ms-appx:///VK.VKUI/VKScheme.xaml"/>
                <ResourceDictionary Source="ms-appx:///VK.VKUI/VKControlStyles.xaml"/>
                <ResourceDictionary Source="ms-appx:///VK.VKUI/VKIcons.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
```
Код выше добавляет ссылки на словари ресурсов vkui. Не меняйте порядок подключаемых словарей ресурсов, палитра (VKPalette.xaml) и схема (VKScheme.xaml) должны быть первым и вторым соответственно.

# Палитра и цветовые схемы.
В VKPalette.xaml содержится цвета (ресурсы Color), а в VKScheme.xaml  схемы (ресурсы Brush) на основе "bright_light" и "space_gray". Также есть VKPaletteMessages.xaml и VKSchemeMessages.xaml, в них находятся цвета, используемые (в будущем?) в сообщениях в официальных мобильных клиентах VK.
Палитра и схемы взяты и сконвертированы [отсюда](https://github.com/VKCOM/Appearance "Appearance").

# Стили для элементов управления
* Кнопки

Стиль для кнопок задаётся вот так:
``` xaml
<Button Style="{StaticResource VKButtonPrimaryMedium}" Content="Hello!"/>
```
Название стиля для кнопок имеют название в формате **VKButton<цвет><размер>**. 

Доступные цвета: ```Primary```, ```Secondary```, ```Tertiary```, ```Outline```, ```Commerce```.

Доступные размеры: ```Medium``` (32px), ```Large``` (36px), ```ExtraLarge``` (44px).

* Поля ввода

Стиль для TextBox задаётся вот так:
``` xaml
<TextBox Style="{StaticResource VKTextBox}" PlaceholderText="Type here..."/>
```
Для PasswordBox:
``` xaml
<PasswordBox Style="{StaticResource VKPasswordBox}" PlaceholderText="Password"/>
```

* Выпадающее меню

Стиль для ComboBox задаётся вот так:
``` xaml
<ComboBox Style="{StaticResource VKComboBox}" SelectedIndex="0"/>
```

# Иконки
Использовать иконки можно следующим образом:
1. В кнопках (Button, AppBarButton и другие, "наследуемые" от ButtonBase):
``` xaml
<Button
        Width="24"
        Height="24"
        ContentTemplate="{StaticResource Icon24Gift}"
        Foreground="{ThemeResource VKButtonSecondaryForegroundBrush}" />
```
2. Во всех остальных местах:
``` xaml
<ContentPresenter
        Width="24"
        Height="24"
        ContentTemplate="{StaticResource Icon24Gift}"
        Foreground="{ThemeResource VKButtonSecondaryForegroundBrush}" />
```

Название ресурсов иконок имеют название в формате **Icon<размер><название>**. Например, ```Icon24Locate```,  ```Icon56MoneyTransferOutline```. Размер и название иконок вы можете узнать [тут](https://vkcom.github.io/icons "VK Icons").
Рекомендуется задавать размер элемента, в котором вы размещаете иконку, такой же, как в иконке.

# Элементы управления
Для использовании элементов управления пропишите в теге Page следующую строку:
``` xaml
xmlns:vkui="using:VK.UI.UWP.Controls"
```
Пример:
``` xaml
<Page
    x:Class="VKUI_UWP_Demo.Pages.PageHeaderDemo"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:VKUI_UWP_Demo.Pages"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:vkui="using:VK.VKU.Controls"
    mc:Ignorable="d">
</Page>
```

## PageHeader
Шапка для страниц. Должна находится в верхней части страницы. Пример:
``` xaml
<vkui:PageHeader Content="Sample header">
    <vkui:PageHeader.LeftButtons>
        <vkui:PageHeaderButton ContentTemplate="{StaticResource Icon28ArrowLeftOutline}"/>
    </vkui:PageHeader.LeftButtons>
    <vkui:PageHeader.RightButtons>
        <vkui:PageHeaderButton ContentTemplate="{StaticResource Icon28AddOutline}"/>
        <vkui:PageHeaderButton ContentTemplate="{StaticResource Icon28MoreHorizontal}"/>
    </vkui:PageHeader.RightButtons>
</vkui:PageHeader>
```
*(тут должен быть скрин)*

## CellButton
Кнопка, занимающая всю ширину и содержащая в себе иконку слева и текст за ней. Пример:
``` xaml
<vkui:CellButton IconTemplate="{StaticResource Icon24SmileOutline}" Text="Иконки"/>
```
*(тут должен быть скрин)*

## Progress
Прогресс-бар `¯\_(ツ)_ /¯`. Пример:
``` xaml
<vkui:Progress Maximum="100" Value="50"/>
```
*(тут должен быть скрин)*

## Spinner
Используется для визуализации выполнения "долгого" процесса. Пример:
``` xaml
<vkui:Spinner Width="44" Height="44"/>
```
Размер спиннера равняется минимальному значению между Width и Height.
*(тут должен быть скрин)*
