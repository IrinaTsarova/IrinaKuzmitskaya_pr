/*
 * (c) Copyright 2022 Marc-Eric Boury
 */

using IrinaKuzmitskaya_pr.Views;
using System.Windows.Forms;

namespace IrinaKuzmitskaya_pr.Views
{
    internal class MainWindow : Form
    {
       public TestView1 displayedPanel { get; internal set; }
    }

    public class TestView1
    {
    }
}