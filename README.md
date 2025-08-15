# vkui-uwp
Стили и иконки VKUI для платформы UWP.

> [!WARNING]
> Библиотека не обновляется с **2021-го года**. За это время в самом VKUI произошли изменения в дизайне элементов управления (a. k. a. компонентов), в наименований элементов и стилей, которые уже есть в этой библиотеке, а также добавлены новые элементы, иконки и цвета и обновлены старые. Библиотека первоначально создана была для проекта, которая позже была портирована на другой фреймворк. Вы можете форкнуть этот репозиторий и внести в нём изменения, добавив новые элементы управления, иконки и цвета или обновив существующие. Или вообще портировать её на Windows App SDK & WinUI 3.

## Подключение VKUI к проекту.
Добавьте ссылку на проект VK.VKUI. Затем в файле **`App.xaml`** добавьте следующий код:

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
Код выше добавляет ссылки на словари ресурсов VKUI. Не меняйте порядок подключаемых словарей ресурсов, палитра (VKPalette.xaml) и схема (VKScheme.xaml) должны быть первым и вторым соответственно.

## Палитра и цветовые схемы.
В `VKPalette.xaml` содержится цвета (ресурсы `Color`), а в `VKScheme.xaml` — схемы (ресурсы `Brush`) на основе `bright_light` и `space_gray. Также есть `VKPaletteMessages.xaml` и `VKSchemeMessages.xaml`, в них находятся цвета, используемые в сообщениях в официальных мобильных клиентах VK.
Палитра и схемы взяты и сконвертированы [отсюда](https://github.com/VKCOM/Appearance).

## Стили для элементов управления
### Кнопки

Стиль для кнопок задаётся вот так:
``` xaml
<Button Style="{StaticResource VKButtonPrimaryMedium}" Content="Hello!"/>
```
Название стиля для кнопок имеют название в формате **VKButton<цвет><размер>**. 

Доступные цвета: ```Primary```, ```Secondary```, ```Tertiary```, ```Outline```, ```Commerce```.

Доступные размеры: ```Medium``` (32px), ```Large``` (36px), ```ExtraLarge``` (44px).

### Поля ввода

Стиль для TextBox задаётся вот так:
``` xaml
<TextBox Style="{StaticResource VKTextBox}" PlaceholderText="Type here..."/>
```
Для PasswordBox:
``` xaml
<PasswordBox Style="{StaticResource VKPasswordBox}" PlaceholderText="Password"/>
```

### Выпадающее меню

Стиль для ComboBox задаётся вот так:
``` xaml
<ComboBox Style="{StaticResource VKComboBox}" SelectedIndex="0"/>
```

## Иконки
Использовать иконки можно следующим образом:
1. В кнопках (Button, AppBarButton и другие, "наследуемые" от ButtonBase):
``` xaml
<Button
        Width="24"
        Height="24"
        ContentTemplate="{StaticResource Icon24Gift}"
        Foreground="{ThemeResource VKButtonSecondaryForegroundBrush}" />
```
2. Использовать новый элемент управления ```VKIcon``` и прописать название иконки в свойстве Id:
``` xaml
<vkui:VKIcon
      Id="Icon28MusicOutline"
      Foreground="{ThemeResource VKButtonSecondaryForegroundBrush}" />
```

Размер и название иконок вы можете узнать на странице "Иконки", либо [тут](https://vkcom.github.io/icons "VK Icons").
Рекомендуется задавать размер элемента, в котором вы размещаете иконку, такой же, как в иконке. Если вы используете ```VKIcon``` для отображения иконок и не задаёте для него размеры, то размер будет задан автоматически в зависимости от иконки. 

## Элементы управления
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

### PageHeader
Шапка для страниц. Должна находится в верхней части страницы. Пример:
``` xaml
<vkui:PageHeader Content="Sample header">
    <vkui:PageHeader.LeftButtons>
        <vkui:PageHeaderButton Icon="Icon28ArrowLeftOutline"/>
    </vkui:PageHeader.LeftButtons>
    <vkui:PageHeader.RightButtons>
        <vkui:PageHeaderButton Icon="Icon28AddOutline"/>
        <vkui:PageHeaderButton Icon="Icon28MoreHorizontal"/>
    </vkui:PageHeader.RightButtons>
</vkui:PageHeader>
```

### CellButton
Кнопка, занимающая всю ширину и содержащая в себе иконку слева и текст за ней.
``` xaml
<vkui:CellButton Icon="Icon24SmileOutline" Text="Иконки"/>
```

### Progress
Прогресс-бар `¯\_(ツ)_ /¯`.
``` xaml
<vkui:Progress Maximum="100" Value="50"/>
```

### Placeholder
Используется для каких-либо заглушек.
``` xaml
<vkui:Placeholder Margin="8,0"
      Icon="Icon56UsersOutline" 
      Header="Уведомления от сообществ" 
      Content="Подключите сообщества, от которых Вы хотите получать уведомления" 
      ActionButtonText="Подключить сообщества"/>
```

### Spinner
Используется для визуализации выполнения "долгого" процесса.
``` xaml
<vkui:Spinner Width="44" Height="44"/>
```
Размер спиннера равняется минимальному значению между Width и Height.

### Alert
Диалоговое окно, по принципу работы похожее на ContentDialog.
``` cs
Alert alert = new Alert
{
    Header = "Удаление сообщения",
    Text = "Вы уверены, что хотите удалить это сообщение?",
    PrimaryButtonText = "Удалить",
    SecondaryButtonText = "Отмена",
    Content = cb
};
AlertButton result = await alert.ShowAsync();```

### Snackbar
Элемент для отображения уведомлений.

``` xaml
<vkui:Snackbar x:Name="Demo4" AfterAvatar="ms-appx:///Assets/SampleAvatars/elor.jpg" Content="Отправлено Эльчину Оруджеву" ActionText="Отменить" Dismissed="Demo4_Dismissed"/>
```

``` cs
private void ShowSnackbar() {
    Demo4.Show();
}

private void Demo4_Dismissed(object sender, bool e)
{
    State.Text = e ? "Cancelled" : "Dismissed automatically";
}
```

### Group
Работает как дефолтный «вертикальный» `StackPanel`, но свойствами `Header` и `Description` можно задавать текст над и под элементами в группе.
``` xaml
<vkui:Group Header="Header" Margin="8,0" Description="Lorem ipsum dolor sit amet">
    <StackPanel>
        <vkui:CellButton Padding="0" Icon="Icon28ChainOutline" Text="Test" Indicator="Enabled"/>
        <vkui:CellButton Padding="0" Icon="Icon28MoonOutline" Text="Dark mode">
            <vkui:CellButton.Indicator>
                <ToggleSwitch/>
            </vkui:CellButton.Indicator>
        </vkui:CellButton>
        <vkui:CellButton Padding="0" Icon="Icon28HelpOutline" Text="Help"/>
    </StackPanel>
</vkui:Group>
```

### Header
Заголовок для отдельных блоков/групп.
``` xaml
<vkui:Header Mode="Primary">Primary</vkui:Header>
```