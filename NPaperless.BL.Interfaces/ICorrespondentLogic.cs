namespace NPaperless.BL.Interfaces {
	public interface ICorrespondentLogic {
		public string CreateCorrespondent();
		public string GetCorrespondent();
		public bool DeleteCorrespondent(int id);
		public string UpdateCorrespondent();

	}
}