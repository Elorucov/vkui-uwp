# vkui-uwp
Стили и иконки VKUI для платформы UWP.

# Подключение VKUI к проекту.
Добавьте ссылку на проект VK.UI.UWP. Затем в файле **App.xaml** добавьте следующий код:

``` xaml
<Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="ms-appx:///VK.UI.UWP/VKPalette.xaml"/>
                <ResourceDictionary Source="ms-appx:///VK.UI.UWP/VKSchemeMilkshake.xaml"/>
                <ResourceDictionary Source="ms-appx:///VK.UI.UWP/VKControlStyles.xaml"/>
                <ResourceDictionary Source="ms-appx:///VK.UI.UWP/VKIcons.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
```
Код выше добавляет ссылки на словари ресурсов vkui. Не меняйте порядок подключаемых словарей ресурсов, палитра (VKPalette.xaml) и схема (VKSchemeMilkshake.xaml) должны быть первым и вторым соответственно.

# Палитра и цветовые схемы.
Доступны две цветовые схемы: VKSchemeDefault.xaml на основе "client_light" и "client_dark", и VKSchemeMilkshake.xaml на основе "bright_light" и "space_gray". Из-за редизайна мобильных клиентов ВК рекомендуется использовать схему VKSchemeMilkshake.xaml.
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
