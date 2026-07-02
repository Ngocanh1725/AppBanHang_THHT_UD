// PROJECT: PluginContract
// FILE: IPlugin.cs
using System.Windows.Forms;

namespace PluginContract
{
    public interface IPlugin
    {
        // 1. Tên của Plugin (đã có từ trước)
        string Name { get; }

        // 2. MỚI: Phiên bản của Plugin (Giúp quản lý cập nhật, VD: "1.0.0")
        string Version { get; }

        // 3. MỚI: Tên tác giả hoặc công ty phát triển Plugin
        string Author { get; }

        // 4. MỚI: Hàm Execute giờ đây nhận vào đối tượng Form gốc (MainForm).
        // Điều này cho phép Plugin "thao túng" giao diện gốc (như đổi màu nền, thêm nút bấm, v.v.)
        void Execute(Form hostForm);
    }
}