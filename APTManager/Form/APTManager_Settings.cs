﻿using System;
using System.Data;
using System.Windows.Forms;

using Haebi.Util;
using APTManager.Query;

namespace APTManager
{
    public partial class APTManager_Settings : Form
    {
        public APTManager_Settings()
        {
            InitializeComponent();
        }

        private void APTManager_Settings_Load(object sender, EventArgs e)
        {
            // 그리드 헤더, 컬럼 설정
            gridCommonCodeGroup.Columns.Clear();
            gridCommonCode.Columns.Clear();

            // 그리드 컬럼 설정
            // colname / colheadertext / alignheader / aligncell / lock / hide
            gridCommonCodeGroup.SetColumn("comname" , "코드명칭", DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true, false);
            gridCommonCodeGroup.SetColumn("comcount", "코드갯수", DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight , true, false);

            gridCommonCodeGroup.Columns[0].Width = 110;
            gridCommonCodeGroup.Columns[1].Width = 80;

            // 그리드 컬럼 설정
            // colname / colheadertext / alignheader / aligncell / lock / hide
            gridCommonCode.SetColumn("comgroup"  , "코드그룹", DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridCommonCode.SetColumn("comcode"   , "코드"    , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridCommonCode.SetColumn("comname"   , "코드명칭", DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridCommonCode.SetColumn("comvalue"  , "값"      , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            gridCommonCode.SetColumn("comremark" , "비고"    , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            
            gridCommonCode.DataSource       = ComCodeQuery.GetComCode();      // 공통코드 조회
            gridCommonCodeGroup.DataSource  = ComCodeQuery.GetComCodeGroup(); // 코드 그룹 조회

            // Row 자동생성 금지
            gridCommonCodeGroup.AllowUserToAddRows  = false;
            gridCommonCode.AllowUserToAddRows       = false;

            // 로우 헤더 숨김 설정
            gridCommonCode.RowHeadersVisible        = false;
            gridCommonCodeGroup.RowHeadersVisible   = false;

            // 로우 선택모드로 설정
            gridCommonCodeGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 공통코드 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 마지막 조회 후 변경된 행만 가져온다
            DataTable saveDT = Global.comcodeDT.GetChanges();

            // 저장 대상이 없으면 그냥 닫는다
            if (saveDT == null || saveDT.Rows.Count == 0)
            {
                HBMessageBox.Show("변경 된 내용이 없습니다");
                return;
            }

            // 저장
            int result = ComCodeQuery.SaveComCode(saveDT);

            // 결과 메시지
            Util.MessageSaveResult(result);

            // 성공 시 창을 닫는다
            if (result > 0)
                Close();
        }

        /// <summary>
        /// 공통코드 그룹 선택 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCommonCodeGroup_MouseUp(object sender, MouseEventArgs e)
        {
            int iCurRow = gridCommonCodeGroup.CurrentCell.RowIndex;

            CommonCodeFilter(gridCommonCodeGroup.Rows[iCurRow].Cells[0].Value.ToString());
        }

        /// <summary>
        /// 공통코드 필터
        /// </summary>
        /// <param name="CodeName"></param>
        private void CommonCodeFilter(string CodeName)
        {
            gridCommonCode.CurrentCell = null;

            for (int i = 0; i < Global.comcodeDT.Rows.Count; i++)
            {
                gridCommonCode.Rows[i].Visible = true;
            }

            for (int i = 0; i < Global.comcodeDT.Rows.Count; i++)
            {
                if (!gridCommonCode.Rows[i].Cells[2].Value.ToString().Equals(CodeName))
                {
                    gridCommonCode.Rows[i].Visible = false;
                }
            }

        }
    }
}
