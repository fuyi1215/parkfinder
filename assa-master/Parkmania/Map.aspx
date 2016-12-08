<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="Parkmania.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    

 <div>
   <div style ="margin-left: auto; text-align:initial;">
      <asp:Label ID="Label1" runat="server" Text="Address:" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>   
       </div>
  <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Labeladdress" runat="server" Text="N/A" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>
</div>
</div>
    <div>
    <div>
        <span>Select: </span>
        <asp:DropDownList ID="DropDownListLinq" runat="server"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Find" OnClientClick="Find(); return false;" OnClick="Button1_Click" />
    
    </div>
 
    <div id="locationList" style="margin-top: 10px; float: left;">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>        
        </div>
    <h4 id="h4"></h4>
    <div id="map_canvas" style=" width:100%; height:500px; float: left;">

    </div>  
    
    </div>
     <div class="col-md-4">
            
        </div>
</asp:Content>
