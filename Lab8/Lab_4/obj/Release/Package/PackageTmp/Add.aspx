<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Lab_4_CSharp.Add1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div style="position:absolute; top:45px; left:196px; width: 992px; height: 1057px;">
       <p>
           
        ФИО клиента: <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
       </p>
        <p>
            Автобус: <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
        </p>
        
            Дата заказа: <asp:TextBox runat="server" ID="dateXEP"  OnTextChanged="dateEx_TextChanged" type="date" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ValidationGroup ="Group1" ID="RequiredFieldValidator1" ControlToValidate="dateXEP" 
                ErrorMessage="Вы не выбрали дату!" Display="dynamic">Вы не выбрали дату!
            </asp:RequiredFieldValidator>
        
         <p>
            Стоимость: <asp:TextBox runat="server" ID="cost" type="number" min="1" value="1000" OnTextChanged="cost_TextChanged"/>
        </p>
        <p>
            <asp:Button ValidationGroup ="Group1" ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" />
            <asp:Label ID="Label2" runat="server" Text="Такая запись уже существует!" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>

       
       
    </div>
</asp:Content>
