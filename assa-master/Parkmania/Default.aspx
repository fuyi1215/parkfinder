<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parkmania._Default" EnableEventValidation ="false" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    
   
</asp:Content> 
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"  >
   
    <div class="jumbotron">
        <h1>Seach</h1>
        <p class="lead">Search different type of Park and Beach
        </p>
        
       <asp:DropDownList ID="DropDownListSearch" runat="server" OnSelectedIndexChanged="DropDownListSearch_SelectedIndexChanged">
           <asp:ListItem>Search Name</asp:ListItem>
           <asp:ListItem>Search Zip</asp:ListItem>
            <asp:ListItem>Search Location</asp:ListItem>
          <asp:ListItem>Search Type</asp:ListItem>
           <asp:ListItem>Search Basketball Feild</asp:ListItem>
           <asp:ListItem>Search Enterance Fee </asp:ListItem>
           <asp:ListItem>No Reservation</asp:ListItem>
       </asp:DropDownList>
        <div>
                       
         <asp:TextBox ID="TextBox1" AutoCompleteType ="Enabled"   runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>            
            <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" Text="Search" />
        </div>
        
        <!-- p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Search</a></p-->
        
        
        
        
             
        
    </div>
       
    <div class="row">
        <div class="col-md-4">
           
            <div>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="25px" Width="446px"></asp:CheckBoxList>
            </div>
     </div>
    </div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">  
        <ProgressTemplate>  
              
  
        <img src="" alt="Loading.. Please wait!"/>  
        </ProgressTemplate>  
    </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
        <ContentTemplate>  
       
                 <div>  
               <asp:GridView ID="GridView1" runat="server"   
                        Width="100%"  HorizontalAlign="Center"  
                        OnRowCommand="GridView1_RowCommand"   
                        AutoGenerateColumns="false"   AllowPaging="false"  
                        DataKeyNames="name"   
                        CssClass="table table-hover table-striped">  
                <Columns>  
                   <asp:ButtonField CommandName="detail"
                         ControlStyle-CssClass="btn btn-info" ButtonType="Button"
                         Text="Detail" HeaderText="Detailed View"/>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="thelocation" HeaderText="Location" />
                    <asp:BoundField DataField="theType" HeaderText="Type of Place" />
                    <asp:BoundField DataField="zip_code" HeaderText="Zip code" />
                    </Columns>  
               </asp:GridView>  
            </div>  
        </ContentTemplate>  
            <Triggers>  
               <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />    
           </Triggers> 
    </asp:UpdatePanel>  
      
    <div id="currentdetail"   class="modal hide fade" 
               tabindex=-1 role="dialog" aria-labelledby="myModalLabel"   
               aria-hidden="true">  
        <div class="modal-header">  
            <button type="button" class="close" data-dismiss="modal"   
                  aria-hidden="true">×</button>  
            <h3 id="myModalLabel">Detailed View</h3>  
       </div>  
   <div class="modal-body">  
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">  
            <ContentTemplate>  
                    <asp:DetailsView ID="DetailsView1" runat="server"   
                              CssClass="table table-bordered table-hover"   
                               BackColor="White" ForeColor="Black"  
                               FieldHeaderStyle-Wrap="false"   
                               FieldHeaderStyle-Font-Bold="true"    
                               FieldHeaderStyle-BackColor="LavenderBlush"   
                               FieldHeaderStyle-ForeColor="Black"  
                               BorderStyle="Groove" AutoGenerateRows="true">  
                        <Fields> 
                        
                        <asp:BoundField DataField="name" HeaderText="Name" />
                            
                        <asp:BoundField DataField="thelocation" HeaderText="Location" />
                        <asp:BoundField DataField="theType" HeaderText="Type of Place" />
                        <asp:BoundField DataField="zip_code" HeaderText="Zip code" />
                        
                       </Fields>  
                  </asp:DetailsView> 
           </ContentTemplate>  
           <Triggers>  
               <asp:AsyncPostBackTrigger ControlID="GridView1"  EventName="RowCommand" />    
           </Triggers>  
           </asp:UpdatePanel>  
                <div class="modal-footer">  
                    <button class="btn btn-info" data-dismiss="modal"   
                            aria-hidden="true">Close</button>  
                </div>  
            </div>  
    </div>  
    
    
       
    
    
    

</asp:Content>
