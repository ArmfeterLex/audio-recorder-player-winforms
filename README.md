# Audio Recorder Player WinForms

Приложение на C# Windows Forms для воспроизведения и записи аудио.

<img width="363" height="272" alt="Снимок экрана 2026-03-01 183257" src="https://github.com/user-attachments/assets/cf5ecd00-4eaa-4962-8152-06bedb3d53b4" />

## Функциональность

### 🎵 Воспроизведение
- WMA через Windows Media Player (COM-объект)
- MIDI через mciSendString (winmm.dll)
- Отображение версии WMP в заголовке окна

### 🎙️ Запись
- Запись с микрофона через NAudio
- Формат: 8000 Гц, моно
- Сохранение в WAV файл
- Кнопки старт/стоп записи

### 📖 Справка
- Вызов справки по .NET
- Показ индекса справки

## Интерфейс

- button1 — воспроизведение WMA
- button2 — воспроизведение MIDI
- button3 — остановка MIDI
- button4 — начать запись
- button5 — остановить запись
- button6 — показать справку
- button7 — показать индекс справки

## Используемые технологии

- NAudio — запись звука
- Windows Media Player COM — WMA
- mciSendString — MIDI
- Help — система справки Windows

## Пути к файлам

- WMA: `E:\Системное программирование\WindowsFormsApp19\music.wma`
- MIDI: `E:\Системное программирование\WindowsFormsApp19\town.MID`
- Запись: `recorded_sound.wav` (в папке программы)
- Справка: `d:\help\dotnet.chm`

## Куда можно встроить

- В аудиоредакторы
- В программы для записи голоса
- В обучающие приложения по работе со звуком
- В демонстрацию работы с NAudio и WinMM

## Требования

- Windows
- .NET Framework / .NET Core с WinForms
- NAudio NuGet пакет
- Windows Media Player (для WMA)
- Микрофон (для записи)

## Примечание

Для работы с WMA требуется установленный Windows Media Player. MIDI воспроизводится через системные MIDI-устройства. Запись использует NAudio — необходимо установить через NuGet.
